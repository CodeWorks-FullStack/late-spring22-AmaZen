import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class WarehouseProductsService {
  async getByWarehouseId(id) {
    const res = await api.get(`api/warehouses/${id}/products`)
    logger.log('get warehouse products', res.data)
    AppState.warehouseProducts = res.data
    AppState.activeWarehouseId = id
  }

  async add(newWP) {
    const res = await api.post('api/warehouseproducts', newWP)
    // THIS IS UNIQUE TO THIS APP
    // only adds products to current list if the activeWarehouse is the same warehouse
    if (AppState.activeWarehouseId == newWP.warehouseId) {
      await this.getByWarehouseId(newWP.warehouseId)
    }
  }
}


export const warehouseProductsService = new WarehouseProductsService()