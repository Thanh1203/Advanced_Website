import { getApiData } from "@/contantApi/getDataApi";
import { createStore } from "vuex";

export const store = createStore({
  state: {
    slidePhotos: [],
    products: [],
    events: [],
  },
  getters: {
    slidePhotos: (state) => state.slidePhotos,
    products: (state) => state.products,
    events: (state) => state.events,
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
  },
  actions: {
    loadProducts({ commit }) {
      try {
        getApiData().then((data) => {
          commit("dumpDataProducts", data.products);
        });
      } catch (error) {
        console.error(error);
      }
    },
    loadEvents({ commit }) {
      try {
        getApiData().then((data) => {
          commit("dumpDataEvents", data.events);
        });
      } catch (error) {
        console.error(error);
      }
    },
    loadSlide({ commit }) {
      try {
        getApiData().then((data) => {
          commit("dumpDataSlide", data.slidePhotos);
        });
      } catch (error) {
        console.error(error);
      }
    },
  },
});
