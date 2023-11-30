import { ID_MOVIE_BUY_TICKET } from "./keyLocalStorage";

export default {
  get() {
    return JSON.parse(localStorage.getItem(ID_MOVIE_BUY_TICKET)) || [];
  },
  set(data) {
    localStorage.setItem(ID_MOVIE_BUY_TICKET, JSON.stringify(data));
  },
};
