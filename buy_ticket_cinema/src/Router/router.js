import { createRouter, createWebHashHistory } from "vue-router";
//* User
import HomeUser from "@/View/HomeUser.vue";
import LoginComponentVue from "@/components/LoginPage/LoginComponent.vue";
import RegisterComponentVue from "@/components/LoginPage/RegisterComponent.vue";
import BuyTicketVue from "@/View/BuyTicket.vue";
//* Admin
import PageLoginAdminVue from "@/View/PageLoginAdmin.vue";
import HomeAdminVue from "@/View/HomeAdmin.vue";

const routes = [
  //* User
  {
    path: "/",
    component: HomeUser,
  },
  {
    path: "/Login",
    component: LoginComponentVue,
  },
  {
    path: "/Register",
    component: RegisterComponentVue,
  },
  {
    path: "/Buy_ticket",
    component: BuyTicketVue,
  },
  //* Admin
  {
    path: "/Login-Admin",
    component: PageLoginAdminVue,
  },
  {
    path: "/Home-Admin",
    component: HomeAdminVue,
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
