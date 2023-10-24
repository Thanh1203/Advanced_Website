const state = {
  movieDetail: [],
};

const getters = {
  movieDetail: (state) => state.movieDetail,
};

const mutations = {
  setMovieDetail(state, data) {
    state.movieDetail = data;
  },
};

const actions = {
  dumpMovieDetail({ commit }, data) {
    commit("setMovieDetail", data);
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
