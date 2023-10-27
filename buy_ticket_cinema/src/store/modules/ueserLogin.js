import stateUserLogin from "@/localStorage/stateUserLogin";

const state = {
  isLoginUser: stateUserLogin.get(),
};

const gettetrs = {
  getIsLoginUser: (state) => state.isLoginUser,
};

const mutations = {
  setIsLoginUser(state, data) {
    state.isLoginUser = data;
    stateUserLogin.set(data);
  },
};

export default {
  state,
  gettetrs,
  mutations,
};
