import { createRouter, createWebHashHistory } from "vue-router";
import HomeUser from "../View/HomeUser.vue";
import PageLogin from "../View/PageLogin.vue";

const routes = [
  {
    path: "/",
    component: HomeUser,
  },
  {
    path: "/Login",
    component: PageLogin,
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
