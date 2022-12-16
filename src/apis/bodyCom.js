import * as api from "../utils/requestV1";

const prefix = "bodyCom"
export async function getAllBodyCom() {
    try {
        let response = await api.get(`${prefix}/getAllBodyCom`)
        console.log(response);
        return response;
    }
    catch (error) {
        console.log(error)
    }
}