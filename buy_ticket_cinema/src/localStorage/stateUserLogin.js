import { USER_LOGIN } from "./keyLocalStorage";

export default {
  get() {
    return JSON.parse(localStorage.getItem(USER_LOGIN)) || [];
  },
  set(data) {
    localStorage.setItem(USER_LOGIN, JSON.stringify(data));
  },
};
