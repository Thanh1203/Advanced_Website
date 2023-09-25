import { createRouter, createWebHashHistory } from "vue-router";
import HomeUser from "../View/HomeUser.vue";
import LoginComponentVue from "@/components/LoginPage/LoginComponent.vue";
import RegisterComponentVue from "@/components/LoginPage/RegisterComponent.vue";
import BuyTicketVue from "@/View/BuyTicket.vue";

const routes = [
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
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
