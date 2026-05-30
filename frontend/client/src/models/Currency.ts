export type Currency = {
    id: number;
    value: number;
    code: string;
    name: string;
    description: string;
    symbol: string;
}

export type InformationCurrency = {
    title: string;
    description: string;
}

export type InformationNeedCurrency = {
    currenciesData: Array<InformationCurrency>;
}