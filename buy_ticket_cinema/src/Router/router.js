import { createRouter, createWebHashHistory } from "vue-router";
//* User
import HomeUser from "@/View/HomeUser.vue";
import PageLoginVue from "@/View/PageLogin.vue";
import BuyTicketVue from "@/View/BuyTicket.vue";
import MovieShowingVue from "@/View/MovieShowing.vue";
import UpComingMovieVue from "@/View/UpComingMovie.vue";
import DetailMovieVue from "@/View/DetailMovie.vue";
import UserInformation from "@/View/UserInformation.vue";
import GitShop from "@/View/GitShop.vue";
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
    component: PageLoginVue,
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
    component: DetailMovieVue,
  },
  {
    path: "/User%20Information",
    component: UserInformation,
  },
  {
    path: "/Git%20Shop",
    component: GitShop,
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
