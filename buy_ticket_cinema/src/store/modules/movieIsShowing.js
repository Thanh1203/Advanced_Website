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
  movieShowing({ commit }, data) {
    const movies = movieFilter(data, 1);
    commit("setMovieIsShowing", movies);
  },
  upComingMovie({ commit }, data) {
    const movies = movieFilter(data, 2);
    commit("setDataUpComingMoive", movies);
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
