import { ID_DETAIL_MOVIE } from "./keyLocalStorage";

export default {
  get() {
    return JSON.parse(localStorage.getItem(ID_DETAIL_MOVIE)) || [];
  },
  set(data) {
    localStorage.setItem(ID_DETAIL_MOVIE, JSON.stringify(data));
  },
};
