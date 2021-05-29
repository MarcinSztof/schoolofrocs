#[derive(Debug, PartialEq, Eq)]
pub struct TreeNode {
    pub val: i32,
    pub left: Option<Rc<RefCell<TreeNode>>>,
    pub right: Option<Rc<RefCell<TreeNode>>>,
}

impl TreeNode {
    #[inline]
    pub fn new(val: i32) -> Self {
        TreeNode {
            val,
            left: None,
            right: None,
        }
    }
}

use std::{
    cell::RefCell,
    cmp::max,
    collections::{hash_map::DefaultHasher, HashMap},
    hash::{Hash, Hasher},
    ops::Deref,
    rc::Rc,
};

struct Solution;

impl Hash for TreeNode {
    fn hash<H: Hasher>(&self, state: &mut H) {
        self.val.hash(state);

        if let Some(l) = self.left.as_ref() {
            let lbor = l.borrow();
            lbor.hash(state);
        } else {
            None::<&TreeNode>.hash(state);
        }

        if let Some(r) = self.right.as_ref() {
            let rbor = r.borrow();
            rbor.hash(state);
        } else {
            None::<&TreeNode>.hash(state);
        }
    }
}

impl Solution {
    pub fn rob(root: Option<Rc<RefCell<TreeNode>>>) -> i32 {
        let mut map = HashMap::new();

        Self::f(root.as_ref(), false, &mut map)
    }

    fn hash_it<T>(obj: T) -> u64
    where
        T: Hash,
    {
        let mut hasher = DefaultHasher::new();
        obj.hash(&mut hasher);
        hasher.finish()
    }

    fn f(
        r: Option<&Rc<RefCell<TreeNode>>>,
        parent_robbed: bool,
        m: &mut HashMap<(u64, bool), i32>,
    ) -> i32 {
        if let Some(node) = r {
            let bor = node.borrow();
            let hash = Self::hash_it(bor.deref());

            if m.contains_key(&(hash, parent_robbed)) {
                return *m.get(&(hash, parent_robbed)).unwrap();
            }

            if parent_robbed {
                return Self::f(bor.right.as_ref(), false, m)
                    + Self::f(bor.left.as_ref(), false, m);
            } else {
                let rob = bor.val
                    + Self::f(bor.right.as_ref(), true, m)
                    + Self::f(bor.left.as_ref(), true, m);
                let not_rob =
                    Self::f(bor.right.as_ref(), false, m) + Self::f(bor.left.as_ref(), false, m);

                let res = max(rob, not_rob);

                m.insert((hash, parent_robbed), res);

                return res;
            }
        }

        0
    }
}
