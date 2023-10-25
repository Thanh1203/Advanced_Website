import idMovieDetailLS from "@/localStorage/idMovieDetailLS";
import mainData from "./mainData";
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
  dumpMovieDetail({ commit }) {
    const data = mainData.getters.products;
    const movieDetail = data.find((item) => item.id == idMovieDetailLS.get());
    commit("setMovieDetail", movieDetail);
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
