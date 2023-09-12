import { createApp } from "vue";
import App from "./App.vue";

//*base css
import "./CSS/base.css";
//* responsive css
import "./CSS/responsive.css";
//* icon
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { fas } from "@fortawesome/free-solid-svg-icons";
//* bootstrap css
import "../node_modules/bootstrap/dist/css/bootstrap.css";

//*store
import { store } from "./store/store";

const app = createApp(App);
library.add(fas);
app.component("font-awesome-icon", FontAwesomeIcon);
app.use(store);

app.mount("#app");
