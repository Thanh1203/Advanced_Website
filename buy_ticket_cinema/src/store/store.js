import { createStore } from "vuex";
import mainData from "./modules/mainData";
import movieCrtUdt from "./modules/movieCrtUdt";
import eventCrtUdt from "./modules/eventCrtUdt";
import slideCrtUdt from "./modules/slideCrtUdt";
import showtimeCrtUdt from "./modules/showtimeCrtUdt";
import movieIsShowing from "./modules/movieIsShowing";
import movieDetail from "./modules/movieDetail";
import buyTicket from "./modules/buyTicket";

export const store = createStore({
  modules: {
    mainData,
    movieCrtUdt,
    eventCrtUdt,
    slideCrtUdt,
    showtimeCrtUdt,
    movieIsShowing,
    movieDetail,
    buyTicket,
  },
  state: {
    isReload: [],
  },
  getters: {
    getIsReload: (state) => state.isReload,
  },
  mutations: {
    setIsReload(state, data) {
      state.isReload = data;
    },
  },
});
