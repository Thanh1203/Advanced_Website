import { createRouter, createWebHashHistory } from "vue-router";
//* User
import HomeUser from "@/View/HomeUser.vue";
import LoginComponentVue from "@/components/LoginPage/LoginComponent.vue";
import RegisterComponentVue from "@/components/LoginPage/RegisterComponent.vue";
import BuyTicketVue from "@/View/BuyTicket.vue";
import MovieShowingVue from "@/View/MovieShowing.vue";
import UpComingMovieVue from "@/View/UpComingMovie.vue";
import DetailMovie from "@/components/DetailPage/bodyDetailProductPage.vue";
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
    path: "/Buy%20ticket",
    component: BuyTicketVue,
  },
  {
    path: "/Movie%20showing",
    component: MovieShowingVue,
  },
  {
    path: "/Up%20coming%20movie",
    component: UpComingMovieVue,
  },
  {
    path: "/Detail%20movie",
    component: DetailMovie,
  },
  //* Admin
  {
    path: "/Admin%20login",
    component: PageLoginAdminVue,
  },
  {
    path: "/Admin%20home",
    component: HomeAdminVue,
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
