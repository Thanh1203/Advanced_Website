import { createApp } from "vue";
import App from "./App.vue";

//*base css
import "./style/base.css";
import "@fontsource/roboto"; // Defaults to weight 400
import "@fontsource/roboto/400.css"; // Specify weight
import "@fontsource/roboto/400-italic.css"; // Specify weight and style
//* responsive css
import "./style/responsive.css";
//* icon
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { fas } from "@fortawesome/free-solid-svg-icons";
//* bootstrap css
import "../node_modules/bootstrap/dist/css/bootstrap.css";
//*store
import { store } from "./store/store";

//*router
import router from "./Router/router";

const app = createApp(App);
library.add(fas);
app.component("font-awesome-icon", FontAwesomeIcon);
app.use(store);
app.use(router);

app.mount("#app");
