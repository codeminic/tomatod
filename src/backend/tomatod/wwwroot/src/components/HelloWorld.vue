<template>
  <h1>Tomatehüsli</h1>
  <div class="telemetry-data-group">
    <div class="telemetry-data-item">
      <div class="telemetry-data-value">25.5</div>
      <div class="telemetry-data-unit">°C</div>
    </div>
    <div class="telemetry-data-item">
      <div class="telemetry-data-value">40</div>
      <div class="telemetry-data-unit">% rH</div>
    </div>
  </div>
  <div class="action-group">
    <button @click="openShutter">🔓 Ufmache</button>
    <button @click="closeShutter">🔒 Zuemache</button>
    <button @click="waterPlants">🚿 Wasser geh</button>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  methods: {
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
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
