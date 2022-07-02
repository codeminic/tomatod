import { VueSignalR } from "@dreamonkey/vue-signalr";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { createApp } from "vue";
import App from "./App.vue";

const connection = new HubConnectionBuilder()
  .withUrl("https://localhost:5001/telemetry-hub")
  .build();

createApp(App).use(VueSignalR, { connection }).mount("#app");
