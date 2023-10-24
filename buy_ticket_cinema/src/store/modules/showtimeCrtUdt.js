const state = {
  infoShowtimeCreate: [],
  reloadShowtime: false,
  isCreateShowtime: false,
};

const getters = {
  infoShowtimeCreate: (state) => state.infoShowtimeCreate,
  reloadShowtime: (state) => state.reloadShowtime,
  isCreateShowtime: (state) => state.isCreateShowtime,
};

const mutations = {
  setInfoShowtimeCreate(state, data) {
    state.infoShowtimeCreate = data;
  },
  setReloadShowtime(state, data) {
    state.reloadShowtime = data;
  },
  setIsCreateShowtime(state, data) {
    state.isCreateShowtime = data;
  },
};

export default {
  state,
  getters,
  mutations,
};
