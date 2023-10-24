const state = {
  infoEventUpdate: "",
  isEditEvent: false,
  isCreateEvent: false,
};

const getters = {
  infoEventUpdate: (state) => state.infoEventUpdate,
  isEditEvent: (state) => state.isEditEvent,
  isCreateEvent: (state) => state.isCreateEvent,
};

const mutations = {
  setInfoEventUpdate(state, data) {
    state.infoEventUpdate = data;
  },
  setIsEditEvent(state, data) {
    state.isEditEvent = data;
  },
  setIsCreateEvent(state, data) {
    state.isCreateEvent = data;
  },
};

export default {
  state,
  getters,
  mutations,
};
