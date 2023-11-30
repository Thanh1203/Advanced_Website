import { getApiDataMovieWithId } from "@/contantApi/getDataApi";
import idMovieBuyTicket from "@/localStorage/idMovieBuyTicket";

const state = {
  movieBuyTicket: [],
};

const getters = {
  getMovieBuyTicket: (state) => state.movieBuyTicket,
};

const mutations = {
  setMovieBuyTicket(state, data) {
    state.movieBuyTicket = data;
  },
};

const actions = {
  insertMovieBuyTicket({ commit }) {
    try {
      getApiDataMovieWithId(idMovieBuyTicket.get()).then((data) => {
        commit("setMovieBuyTicket", data);
      });
    } catch (error) {
      console.error(error);
    }
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
