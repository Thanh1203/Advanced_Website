import {
  getApiDataEvent,
  getApiDataMovie,
  getApiDataSlide,
} from "@/contantApi/getDataApi";
import movieIsShowing from "./movieIsShowing";
import movieDetail from "./movieDetail";
import idMovieDetailLS from "@/localStorage/idMovieDetailLS";

const state = {
  slidePhotos: [],
  products: [],
  events: [],
};

const getters = {
  slidePhotos: (state) => state.slidePhotos,
  products: (state) => state.products,
  events: (state) => state.events,
};

const mutations = {
  dumpDataProducts(state, data) {
    state.products = data;
  },
  dumpDataEvents(state, data) {
    state.events = data;
  },
  dumpDataSlide(state, data) {
    state.slidePhotos = data;
  },
};

const actions = {
  loadProducts({ commit }) {
    try {
      getApiDataMovie()
        .then((data) => {
          commit("dumpDataProducts", data);
        })
        .then(() => {
          const result = state.products;
          movieIsShowing.actions.movieShowing({ commit }, result);
          movieIsShowing.actions.upComingMovie({ commit }, result);
          result.forEach((item) => {
            if (item.id == idMovieDetailLS.get()) {
              movieDetail.actions.dumpMovieDetail({ commit }, item);
            }
          });
        });
    } catch (error) {
      console.error(error);
    }
  },
  loadEvents({ commit }) {
    try {
      getApiDataEvent().then((data) => {
        commit("dumpDataEvents", data);
      });
    } catch (error) {
      console.error(error);
    }
  },
  loadSlide({ commit }) {
    try {
      getApiDataSlide().then((data) => {
        commit("dumpDataSlide", data);
      });
    } catch (error) {
      console.error(error);
    }
  },
};
export default { state, getters, mutations, actions };
