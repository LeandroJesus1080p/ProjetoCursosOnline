export interface Response<T>{
    datos: T;
    mensagem: string;
    status: boolean;
}