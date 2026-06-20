import type { InformationNeedCurrency } from '../../../models/Currency';
import { CurrencyDescription } from './CurrencyDescription';
import styles from './InformationAboutCurrencies.module.scss'

export const InformationAboutCurrencies = ({ currenciesData }: InformationNeedCurrency) => {
    return (
        <div className={styles.infoContainer}>
            {currenciesData.map((currency) => (
                <CurrencyDescription
                    title={currency.title}
                    description={currency.description}
                />
            ))}
        </div>
    );
};