import * as api from "../utils/requestV1";

const prefix = "prism"
export async function getAllPrisms() {
    try {
        let response = await api.get(`${prefix}/getAllPrisms`)
        return response;
    }
    catch (error) {
        console.log(error)
    }
}