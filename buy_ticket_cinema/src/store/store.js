import {
  getApiDataMovie,
  getApiDataSlide,
  getApiDataEvent,
} from "@/contantApi/getDataApi";
import { createStore } from "vuex";

export const store = createStore({
  state: {
    slidePhotos: [],
    products: [],
    events: [],
    infoMovieUpdate: [],
    infoEventUpdate: [],
    infoSlideUpdate: [],
    infoShowtimeCreate: [],
    reloadShowtime: false,
    isEditMovie: false,
    isEditEvent: false,
    isEditSlide: false,
  },
  getters: {
    slidePhotos: (state) => state.slidePhotos,
    products: (state) => state.products,
    events: (state) => state.events,
    infoMovieUpdate: (state) => state.infoMovieUpdate,
    infoEventUpdate: (state) => state.infoEventUpdate,
    infoSlideUpdate: (state) => state.infoSlideUpdate,
    infoShowtimeCreate: (state) => state.infoShowtimeCreate,
    reloadShowtime: (state) => state.reloadShowtime,
    isEditMovie: (state) => state.isEditMovie,
    isEditEvent: (state) => state.isEditEvent,
    isEditSlide: (state) => state.isEditSlide,
  },
  mutations: {
    dumpDataProducts(state, data) {
      state.products = data;
    },
    dumpDataEvents(state, data) {
      state.events = data;
    },
    dumpDataSlide(state, data) {
      state.slidePhotos = data;
    },
    setInfoMovieUpdate(state, data) {
      state.infoMovieUpdate = data;
    },
    setInfoEventUpdate(state, data) {
      state.infoEventUpdate = data;
    },
    setInfoSlideUpdate(state, data) {
      state.infoSlideUpdate = data;
    },
    setInfoShowtimeCreate(state, data) {
      state.infoShowtimeCreate = data;
    },
    setReloadShowtime(state, data) {
      state.reloadShowtime = data;
    },
    setIsEditMovie(state, data) {
      state.isEditMovie = data;
    },
    setIsEditEvent(state, data) {
      state.isEditEvent = data;
    },
    setIsEditSlide(state, data) {
      state.isEditSlide = data;
    },
  },
  actions: {
    loadProducts({ commit }) {
      try {
        getApiDataMovie().then((data) => {
          commit("dumpDataProducts", data);
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
  },
});
