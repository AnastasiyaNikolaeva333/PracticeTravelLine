import type { InformationNeedCurrency } from '../../../models/CurrencyInfo';
import { CurrencyDescription } from './CurrencyDescription';
import styles from './InformationAboutCurrencies.module.scss';

export const InformationAboutCurrencies = ({ currenciesData }: InformationNeedCurrency) => {
  return (
    <div className={styles.infoContainer}>
      {currenciesData.map((currency) => (
        <CurrencyDescription code={currency.code} title={currency.title} description={currency.description} />
      ))}
    </div>
  );
};
