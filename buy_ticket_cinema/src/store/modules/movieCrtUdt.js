const state = {
  infoMovieUpdate: [],
  isEditMovie: false,
  isCreateMoive: false,
};

const getters = {
  infoMovieUpdate: (state) => state.infoMovieUpdate,
  isEditMovie: (state) => state.isEditMovie,
  isCreateMoive: (state) => state.isCreateMoive,
};

const mutations = {
  setInfoMovieUpdate(state, data) {
    state.infoMovieUpdate = data;
  },
  setIsEditMovie(state, data) {
    state.isEditMovie = data;
  },
  setIsCreateMoive(state, data) {
    state.isCreateMoive = data;
  },
};

export default {
  state,
  getters,
  mutations,
};
