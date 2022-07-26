import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class WarehousesService {
  async getAll() {
    const res = await api.get('api/warehouses')
    logger.log(res.data)
    AppState.warehouses = res.data
  }
}

export const warehousesService = new WarehousesService()