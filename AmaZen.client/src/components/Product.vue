<template>
  <div class="product row my-2 p-2 border">
    <div class="col-2">{{ product.name }}</div>
    <div class="col-6">{{ product.description }}</div>
    <div class="col-2 text-center">{{ product.quantity }}</div>
    <div class="col-2 text-end" v-if="product.warehouseProductId">
      <button class="btn btn-danger">Remove</button>
    </div>
    <div class="col-2 text-end" v-else>
      <div>
        <label for="quantity">Quantity: </label>
        <input type="number" v-model="quantity">
      </div>
      <select class="form-control" name="location" id="location" v-model="warehouseId">
        <option v-for="w in warehouses" :key="w.id" :value="w.id">{{ w.name }}</option>
      </select>
      <button class="btn btn-success" @click="add">Add</button>
    </div>
  </div>
</template>


<script>
import { computed, ref } from 'vue'
import { AppState } from '../AppState.js'
import { warehouseProductsService } from '../services/WarehouseProductsService.js'
import Pop from '../utils/Pop.js'
export default {
  props: {
    product: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const warehouseId = ref(0)
    const quantity = ref(0)
    return {
      warehouseId,
      quantity,
      warehouses: computed(() => AppState.warehouses),
      async add() {
        try {
          // what is a relationship object
          const newWarehouseProduct = {
            warehouseId: warehouseId.value,
            quantity: quantity.value,
            productId: props.product.id
          }
          await warehouseProductsService.add(newWarehouseProduct)

          warehouseId.value = 0
          quantity.value = 0
          Pop.toast("successfully added")
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
</style>