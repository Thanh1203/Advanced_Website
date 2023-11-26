const state = {
  isUpdateUser: 0,
};
const getters = {
  getIsUpdateUser: (state) => state.isUpdateUser,
};
const mutations = {
  setIsUpdate(state, data) {
    state.isUpdateUser = data;
  },
};
const actions = {
  importIsUpdate({ commit }, data) {
    commit("setIsUpdate", data);
  },
};
export default {
  state,
  getters,
  mutations,
  actions,
};
