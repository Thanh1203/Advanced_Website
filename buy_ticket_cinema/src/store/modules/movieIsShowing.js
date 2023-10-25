import { getApiDataMovie } from "@/contantApi/getDataApi";

const state = {
  dataMovieIsShowing: [],
  dataUpComingMovie: [],
};

const getters = {
  dataMovieIsShowing: (state) => state.dataMovieIsShowing,
  dataUpComingMovie: (state) => state.dataUpComingMovie,
};

const mutations = {
  setMovieIsShowing(state, data) {
    state.dataMovieIsShowing = data;
  },
  setDataUpComingMoive(state, data) {
    state.dataUpComingMovie = data;
  },
};

const actions = {
  movieShowing({ commit }) {
    getApiDataMovie()
      .then((data) => {
        return movieFilter(data, 1);
      })
      .then((data) => {
        commit("setMovieIsShowing", data);
      });
  },
  upComingMovie({ commit }) {
    getApiDataMovie()
      .then((data) => {
        return movieFilter(data, 2);
      })
      .then((data) => {
        commit("setDataUpComingMoive", data);
      });
  },
};

function movieFilter(data, value) {
  let result = [];
  data.forEach((element) => {
    if (element.status === value) {
      result.push(element);
    }
  });
  return result;
}

export default {
  state,
  getters,
  mutations,
  actions,
};
