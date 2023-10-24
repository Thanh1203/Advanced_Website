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
  insertMovieBuyTicket({ commit }, data) {
    commit("setMovieBuyTicket", data);
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
