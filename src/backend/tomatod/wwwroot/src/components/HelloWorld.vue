<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <button @click="openShutter">Open shutter</button>
    <button @click="closeShutter">Close shutter</button>
    <button @click="waterPlants">Water plants</button>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String,
  },
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
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
