import type { Currency } from '../../../models/Currency';
import styles from './Header.module.scss'

type HeaderCurrency = Pick<Currency, `name` | `value`>;

type HeaderProps = {
    from: HeaderCurrency;
    to: HeaderCurrency;
    date: Date;
}

export const Header = ({ from, to, date }: HeaderProps) => {
    return (
        <>
            <p className={styles.informationTranslationFrom}>
                {from.value} {from.name} is
            </p>
            <p className={styles.informationTranslationTo}>
                {to.value} {to.name}
            </p>
            <p className={styles.informationData}>{date.toUTCString()}</p>
        </>
    );
};