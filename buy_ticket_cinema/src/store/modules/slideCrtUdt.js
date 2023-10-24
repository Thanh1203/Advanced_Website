const state = {
  infoSlideUpdate: [],
  isEditSlide: false,
  isCreateSlide: false,
};

const getters = {
  infoSlideUpdate: (state) => state.infoSlideUpdate,
  isEditSlide: (state) => state.isEditSlide,
  isCreateSlide: (state) => state.isCreateSlide,
};

const mutations = {
  setInfoSlideUpdate(state, data) {
    state.infoSlideUpdate = data;
  },
  setIsEditSlide(state, data) {
    state.isEditSlide = data;
  },
  setIsCreateSlide(state, data) {
    state.isCreateSlide = data;
  },
};

export default {
  state,
  getters,
  mutations,
};
