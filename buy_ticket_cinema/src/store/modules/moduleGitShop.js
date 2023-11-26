const state = {
  selectGitShop: 0,
};

const getters = {
  getSelectGitShop: (state) => state.selectGitShop,
};
const mutations = {
  setSelectGitShop(state, data) {
    state.selectGitShop = data;
  },
};
const actions = {
  changeSelectGitshop({ commit }, data) {
    commit("setSelectGitShop", data);
  },
};
export default {
  state,
  getters,
  mutations,
  actions,
};
