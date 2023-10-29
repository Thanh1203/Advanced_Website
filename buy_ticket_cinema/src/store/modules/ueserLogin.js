const state = {
  inLoginUser: true,
  isLoginUser: false,
};

const getters = {
  getInLoginUser: (state) => state.inLoginUser,
  getIsLoginUser: (state) => state.isLoginUser,
};

const mutations = {
  setInLoginUser(state, data) {
    state.inLoginUser = data;
  },
  setIsLoginUser(state, data) {
    state.isLoginUser = data;
  },
};

const actions = {
  loadIsLoginUser({ commit }) {
    const data = window.sessionStorage.getItem("islogin");
    if (data) {
      commit("setIsLoginUser", JSON.parse(data));
    }
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
