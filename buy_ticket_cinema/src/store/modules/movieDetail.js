import { getApiDataMovieWithId } from "@/contantApi/getDataApi";
import idMovieLS from "@/localStorage/idMovieLS";

const state = {
  movieDetail: [],
};

const getters = {
  getMovieDetail: (state) => state.movieDetail,
};

const mutations = {
  setMovieDetail(state, data) {
    state.movieDetail = data;
  },
};

const actions = {
  loadMovieDetail({ commit }) {
    try {
      getApiDataMovieWithId(idMovieLS.get()).then((data) => {
        commit("setMovieDetail", data);
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
