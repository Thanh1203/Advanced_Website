import { getApiDataMovieWithId } from "@/contantApi/getDataApi";

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
      getApiDataMovieWithId().then((data) => {
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
