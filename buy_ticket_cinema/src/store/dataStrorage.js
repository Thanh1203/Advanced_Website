const BUY_TICKET_CINEMA = "BUY_TICKET_CINEMA";

export default {
  get() {
    return JSON.parse(localStorage.getItem(BUY_TICKET_CINEMA)) || [];
  },
  set(todos) {
    localStorage.setItem(BUY_TICKET_CINEMA, JSON.stringify(todos));
  },
};
