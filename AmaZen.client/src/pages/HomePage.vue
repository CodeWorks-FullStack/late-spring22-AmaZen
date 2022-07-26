<template>
  <div class="container">
    <div class="row m-3 bg-white elevation-1">
      <div class="col-12">
        <div class="d-flex justify-content-between align-items-center">
          <h2 class="m-0">Warehouse Products</h2>
          <div class="mb-3">
            <label for="location" class="form-label my-1">Location:</label>
            <select class="form-control" name="location" id="location" @change="setActiveWarehouse"
              v-model="activeWarehouseId">
              <option v-for="w in warehouses" :key="w.id" :value="w.id">{{ w.name }}</option>
            </select>
          </div>
        </div>
      </div>
      <div class="col-12 p-3 bg-light">
        <Product v-for="p in warehouseProducts" :key="p.id" :product="p" />
      </div>
    </div>
    <div class="row m-3 bg-white elevation-1">
      <div class="col-12">
        <div class="d-flex justify-content-between align-items-center">
          <h2 class="m-0">All Products</h2>
          <div class="mb-3">
            <label for="location" class="form-label my-1">Category:</label>
            <select class="form-control" name="location" id="location">
              <option>all</option>
              <option>Books</option>
              <option>Equipment</option>
              <option>Food</option>
            </select>
          </div>
        </div>
      </div>
      <div class="col-12 p-3 bg-light">
        <div v-for="p in products" :key="p.id">
          <Product :product="p" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue'
import { AppState } from '../AppState.js'
import { productsService } from '../services/ProductsService.js'
import { warehouseProductsService } from '../services/WarehouseProductsService.js'
import { warehousesService } from '../services/WarehousesService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
export default {
  setup() {
    const activeWarehouseId = ref(0)
    onMounted(async () => {
      try {
        await warehousesService.getAll()
        await productsService.getAll()
      } catch (error) {
        logger.log(error)
        Pop.toast("Something Went Wrong", "error")
      }
    })
    return {
      activeWarehouseId,
      products: computed(() => AppState.products),
      warehouses: computed(() => AppState.warehouses),
      warehouseProducts: computed(() => AppState.warehouseProducts),
      async setActiveWarehouse() {
        try {
          await warehouseProductsService.getByWarehouseId(activeWarehouseId.value)
        } catch (error) {
          logger.error(error)
          Pop.toast(error, "error")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">

</style>