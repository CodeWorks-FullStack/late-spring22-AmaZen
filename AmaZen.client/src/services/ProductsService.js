import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"

class ProductsService {
  async getAll() {
    const res = await api.get('api/products')
    AppState.products = res.data
  }
}

export const productsService = new ProductsService()