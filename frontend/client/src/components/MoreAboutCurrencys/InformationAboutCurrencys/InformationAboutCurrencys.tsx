import styles from './InformationAboutCurrencys.module.scss'
import type { InformationNeedCurrency } from '../../../models/Currency';
import { CurrencyDescription } from './CurrencyDescription';

export const InformationAboutCurrencys = ({ currenciesData }: InformationNeedCurrency) => {
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