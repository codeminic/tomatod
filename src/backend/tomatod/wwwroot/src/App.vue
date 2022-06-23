<template>
  <div class="tomato-title">🍅</div>
  <HelloWorld />
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: "App",
  components: {
    HelloWorld,
  },
};
</script>

<style>
#app {
  text-align: center;
}

body {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  color: #2c3e50;
}

.tomato-title {
  font-size: 5rem;
}
</style>
