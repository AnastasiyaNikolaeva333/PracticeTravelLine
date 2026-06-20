import type { Currency } from './Currency';

export type CurrencyAllInfo = Currency & {
  value: number;
};

export type CurrencyTransferCurrency = Pick<CurrencyAllInfo, `name` | `code` | `value`>;

export type InformationCurrency = {
  code: string;
  title: string;
  description: string;
};

export type InformationNeedCurrency = {
  currenciesData: InformationCurrency[];
};
