import type { InformationNeedCurrency } from '../../models/Currency';
import { ButtonMore } from './ButtonMore/ButtonMore';
import { InformationAboutCurrencys } from './InformationAboutCurrencys/InformationAboutCurrencys';
import styles from './MoreAboutCurrencys.module.scss';

export const MoreAboutCurrencys = ({ currenciesData }: InformationNeedCurrency) => {
    return (
        <div className={styles.information}>
            <ButtonMore />
            <InformationAboutCurrencys currenciesData={currenciesData} />
        </div>
    );
};