import { ButtonMore } from './ButtonMore';
import { InformationAboutCurrencys } from './InformationAboutCurrencys';
import styles from './MoreAboutCurrencys.module.scss';

export const MoreAboutCurrencys = () => {
    return (
        <div className={styles.information}>
            <ButtonMore />
            <InformationAboutCurrencys />
        </div>
    );
};