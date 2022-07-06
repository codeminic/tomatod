<template>
  <h1>Tomatehüsli</h1>
  <div class="telemetry-data-group">
    <div class="telemetry-data-item">
      <div
        class="telemetry-data-value"
        style="text-align: center; width: 200px; font-size: 1.2em"
      >
        {{ translateShutterState(shutter) }}
      </div>
    </div>
    <div class="telemetry-data-item">
      <div class="telemetry-data-value">{{ temperature || "--" }}</div>
      <div class="telemetry-data-unit">°C</div>
    </div>
    <div class="telemetry-data-item">
      <div class="telemetry-data-value">{{ humidity || "--" }}</div>
      <div class="telemetry-data-unit">%</div>
    </div>
  </div>
  <div class="action-group">
    <button @click="openShutter">🔓 Ufmache</button>
    <button @click="closeShutter">🔒 Zuemache</button>
    <button @click="waterPlants">🚿 Wasser geh</button>
  </div>
</template>

<script>
import { useSignalR } from "@dreamonkey/vue-signalr";

export default {
  data() {
    return {
      temperature: null,
      humidity: null,
      shutter: null,
    };
  },
  mounted() {
    const signalr = useSignalR();

    signalr.on("SendState", (jsonMessage) => {
      console.log(jsonMessage);
      let message = JSON.parse(jsonMessage);
      this.temperature = message.temperature;
      this.humidity = message.humidity;
      this.shutter = message.shutterState;
    });
  },
  name: "HelloWorld",
  methods: {
    translateShutterState: function () {
      switch (this.shutter) {
        case "Open":
          return "Offe";
        case "Closed":
          return "Zue";
        case "Opening":
          return "Bin am ufmache..";
        case "Closing":
          return "Bin am zuemache..";
        default:
          return "Weiss gad nöd.. 😐";
      }
    },
    openShutter: async function () {
      await fetch("/api/greenhouse/shutter/open", { method: "POST" });
    },
    closeShutter: async function () {
      await fetch("/api/greenhouse/shutter/close", { method: "POST" });
    },
    waterPlants: async function () {
      await fetch("/api/greenhouse/water", { method: "POST" });
    },
  },
};
</script>

<style scoped>
.telemetry-data-group {
  display: flex;
  flex-direction: column;
  align-content: center;
  align-items: center;
  margin-bottom: 20px;
}

.telemetry-data-item {
  display: flex;
  flex-direction: row;
  align-content: space-between;
  align-items: center;
}

.telemetry-data-value {
  font-size: 1.5em;
  width: 120px;
  text-align: end;
}

.telemetry-data-unit {
  font-size: 0.8em;
  width: 100px;
  margin-left: 5px;
  text-align: start;
}

.action-group {
  display: flex;
  flex-direction: column;
  align-content: center;
  align-items: center;
}

button {
  font-size: 1.2em;
  width: 80%;
  height: 40px;
  max-width: 200px;
  border: 0px solid lightgray;
  border-radius: 5px;
  margin: 5px;
  background-color: #d7e3ee;
}

button:hover {
  background-color: #c4cfda;
}

button:active {
  background-color: #adb8c2;
}
</style>
