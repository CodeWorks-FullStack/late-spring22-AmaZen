<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>
    <div class="bg-dark text-light text-center p-4"> Made with 💖 by CodeWorks </div>
  </footer>
  <!-- Floating Action Button FAB -->
  <div class="fab">
    <button class="btn btn-success rounded-pill f-22 elevation-2"><i class="mdi mdi-plus"></i></button>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

.fab {
  position: fixed;
  bottom: 1em;
  right: 1em
}
</style>
