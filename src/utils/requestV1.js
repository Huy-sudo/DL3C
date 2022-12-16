import axios from "axios"

const instance = axios.create({
    baseURL: "https://dl3c-be.ndxcode.tk/api/v1/",
    timeout: 5000,
    headers: {
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
    },
});

instance.interceptors.response.use(
    (response) => {
        return response;
    },
    (error) => {
        if (!error.response) {
            return {
                data: {
                    status: 0,
                    message: "Please check your internet connection.",
                },
            };
        }
        return Promise.reject(error);
    }
);


export async function get(routes, options = {}) {
    let response = await instance.get(routes, options);
    return response;
}

export async function post(routes, options = {}) {
    let response = await instance.post(routes, options);
    return response;
}

export async function put(routes, options = {}) {
    let response = await instance.put(routes, options);
    return response;
}

export async function del(routes, options = {}) {
    let response = await instance.delete(routes, options);
    return response;
}