
import type { InformationNeedCurrency } from '../../models/Currency';
import { ButtonMore } from './ButtonMore/ButtonMore';
import { InformationAboutCurrencies } from './InformationAboutCurrencies/InformationAboutCurrencies';
import styles from './MoreAboutCurrencies.module.scss';

export const MoreAboutCurrencies = ({ currenciesData }: InformationNeedCurrency) => {
    return (
        <div className={styles.information}>
            <ButtonMore />
            <InformationAboutCurrencies currenciesData={currenciesData} />
        </div>
    );
};